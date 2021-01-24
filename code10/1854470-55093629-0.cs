        class Program
        {
            static void Main(string[] args)
            {
            }
            //public DataStructures DataStructure = new DataStructures();
            public static List<DataStructure.MeasurementData> RawResult(List<DataStructure.MeasurementRawTableSQL> rawData, int _Test_ID)
            {
                if (rawData != null)
                {
                    double? _Voltage = null;
                    double? _Current = null;
                    double? _Charge_Capacity = null;
                    double? _Discharge_Capacity = null;
                    var result = rawData.GroupBy(x => x.Date_Time)
                         .Select(gr =>
                         {
                             var _Date_Time = gr.Key;
                             var _Channel = gr.FirstOrDefault().Channel;
                             var _Voltage_Row = gr.Where(x => x.Data_Type == 21).FirstOrDefault();
                             if(_Voltage_Row != null) _Voltage = _Voltage_Row.Data_Value;
                             var _Current_Row = gr.Where(x => x.Data_Type == 22).FirstOrDefault();
                             if(_Current_Row != null) _Current = _Current_Row.Data_Value;
                             var _Charge_Capacity_Row = gr.Where(x => x.Data_Type == 23).FirstOrDefault();
                             if (_Charge_Capacity_Row != null) _Charge_Capacity = _Charge_Capacity_Row.Data_Value; 
                             var _Discharge_Capacity_Row = gr.Where(x => x.Data_Type == 24).FirstOrDefault();
                             if (_Discharge_Capacity_Row != null) _Discharge_Capacity = _Discharge_Capacity_Row.Data_Value; 
                             return new DataStructure.MeasurementData
                             {
                                 Test_ID = _Test_ID,
                                 Channel = _Channel,
                                 Date_Time = _Date_Time,
                                 Current = _Current,
                                 Voltage = _Voltage,
                                 Charge_Capacity = _Charge_Capacity,
                                 Discharge_Capacity = _Discharge_Capacity
                             };
                         }
                         ).ToList();
                    return result;
                }
                else return null;
            }
        }
        public class DataStructure
        {
            public class MeasurementData
            {
                public int? Test_ID { get; set; }
                public int? Channel { get; set; }
                public DateTime Date_Time { get; set; }
                public double? Current { get; set; }
                public double? Voltage { get; set; }
                public double? Charge_Capacity { get; set; }
                public double? Discharge_Capacity { get; set; }
            }
            public class MeasurementRawTableSQL
            {
                public DateTime Date_Time { get; set; }
                public int Channel { get; set; }
                public int Data_Type { get; set; }
                public double Data_Value { get; set; }
            }
        }
