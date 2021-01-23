        private static DifferentTypes Approachs(string stringToDecompose, string text2Write)
        {
            DifferentTypes differentTypes;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                var strs = stringToDecompose.SaeedsApproach(10);
                foreach (var item in strs)
                { 
                }
            }
            sw.Stop();
            Console.WriteLine("Saeed's Approach takes {0} millisecond for {1} strings", sw.ElapsedMilliseconds, text2Write);
            differentTypes.saeed = sw.ElapsedMilliseconds;
            sw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                var strs = stringToDecompose.JaysApproach(10);
                foreach (var item in strs)
                {
                }
            }
            sw.Stop();
            Console.WriteLine("Jay's Approach takes {0} millisecond for {1} strings", sw.ElapsedMilliseconds, text2Write);
            differentTypes.Jay = sw.ElapsedMilliseconds;
            //sw.Restart();
            //for (int i = 0; i < 1000; i++)
            //{
            //    IEnumerable<string> strs = stringToDecompose.DanTaosApproch(10);
            //    foreach (var item in strs)
            //    {
            //    }
            //}
            //sw.Stop();
            //Console.WriteLine("Dan's Approach takes {0} millisecond for {1} strings", sw.ElapsedMilliseconds, text2Write);
            sw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                var strs = stringToDecompose.SimmonsApproach(10);
                foreach (var item in strs)
                {
                }
            }
            sw.Stop();
            Console.WriteLine("Simmon's Approach takes {0} millisecond for {1} strings", sw.ElapsedMilliseconds, text2Write);
            differentTypes.Simmon = sw.ElapsedMilliseconds;
            return differentTypes;
        }
