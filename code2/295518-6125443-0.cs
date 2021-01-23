            List<object> values = new List<object>();
            values.ForEach(value =>
                               {
                                   System.Diagnostics.Debug.WriteLine(value.ToString());
                                   System.Diagnostics.Debug.WriteLine("Some other action");
                               }
                );
