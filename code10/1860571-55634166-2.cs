    using System;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    public class ParallelCalculation
    {
        public delegate void CompletionHandler(DataTable result, Exception exception);
        public DataTable Prof, Prop, Rango;
        class Part
        {
            public DataTable Result;
            public int FromRow, ToRow;
            public float Progress;
            public Exception Exception;
        }
        DataTable result;
        Part[] parts;
        Task[] tasks;
        CancellationToken cancellation;
        CompletionHandler callback;
        public async void Run(CompletionHandler callback, CancellationToken token, int threadCount = 0)
        {
            this.cancellation = token;
            this.callback = callback;
            await Task.Factory.StartNew(Perform, threadCount);
        }
        async void Perform(object state)
        {
            int threadCount = (int)state;
            try
            {
                // Create table for results
                result = new DataTable();
                result.Columns.Add("Prof Evaluar", typeof(double));
                result.Columns.Add("Profundidad", typeof(double));
                result.Columns.Add("Promedio", typeof(double));
                result.Columns.Add("Sumatoria", typeof(double));
                result.Columns.Add("n", typeof(double));
                for (int i = 0; i < Rango.Rows.Count; i++)
                    result.Rows.Add(Rango.Rows[i][0], Rango.Rows[i][1], 0, 0, 0);
                // Split calculation into n tasks. Tasks work in parallel,
                // each one processes it's own stripe of data, defined by the instance of the Part class.
                int n = threadCount > 0 ? threadCount : Environment.ProcessorCount;
                tasks = new Task[n];
                parts = new Part[n];
                int rowsPerTask = Prof.Rows.Count / n;
                int rest = Prof.Rows.Count % n;
                for (int i = 0, from = 0, to = 0; i < n; ++i, --rest, from = to)
                {
                    to = from + rowsPerTask + (rest > 0 ? 1 : 0);
                    parts[i] = new Part { FromRow = from, ToRow = to };
                    tasks[i] =  Task.Factory.StartNew(CalculatePart, parts[i]);
                }
                // Wait until all partial calculations are finished
                await Task.WhenAll(tasks);
                // Sum partial results to the main result table (and find the first exception, if any)
                Exception e = null;
                foreach (var part in parts)
                {
                    e = e ?? part.Exception;
                    for (int row = 0; row < result.Rows.Count; ++row)
                    {
                        result.Rows[row][3] = Convert.ToDouble(result.Rows[row][3]) + Convert.ToDouble(part.Result.Rows[row][3]);
                        result.Rows[row][4] = Convert.ToInt32(result.Rows[row][4]) + Convert.ToInt32(part.Result.Rows[row][4]);
                    }
                }
                // Remove empty rows from results
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    if (Convert.ToInt32(result.Rows[i][4]) == 0)
                    {
                        result.Rows[i].Delete();
                        i -= 1;
                    }
                }
                // Call back 
                callback?.Invoke(result, e);
            }
            catch (Exception e)
            {
                callback?.Invoke(null, e);
            }
        }
        void CalculatePart(object state)
        {
            var part = (Part)state;
            try
            {
                // Create our own table for partial results.
                part.Result = this.result.Copy();
                var result = part.Result; // Just a shortcut
                int cols = Prop.Columns.Count;
                int steps = cols * (part.ToRow - part.FromRow);
                for (int i = part.FromRow, step = 1; i < part.ToRow; i++)
                {
                    for (int j = 0; j < cols; j++, step++)
                    {
                        var prop_celda_obj = Prop.Rows[i][j];
                        if (prop_celda_obj != DBNull.Value)
                        {
                            double prop_celda = Convert.ToDouble(prop_celda_obj);
                            double prof_celda = Convert.ToDouble(Prof.Rows[i][j]);
                            for (int k = 0; k < Rango.Rows.Count; k++)
                            {
                                //double prof_celda = Convert.ToDouble(Prof.Rows[i][j]);
                                double prof_rango = Convert.ToDouble(Rango.Rows[k][0]);
                                if (prof_celda < prof_rango)
                                {
                                    result.Rows[k][3] = Convert.ToDouble(result.Rows[k][3]) + prop_celda;
                                    result.Rows[k][4] = Convert.ToDouble(result.Rows[k][4]) + 1;
                                    break;
                                }
                            }
                        }
                        part.Progress = step / (float)steps;
                        if (cancellation.IsCancellationRequested)
                            return;
                    }
                }
            }
            catch (Exception e)
            {
                part.Exception = e;
            }
        }
        public float Progress()
        {
            float sum = 0.0f;
            foreach (var part in parts)
                sum += part.Progress;
            return sum / parts.Length;
        }
    }
