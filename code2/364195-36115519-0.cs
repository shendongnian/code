                for (int i = 0; i < target.Length; i++)
                {
                    string v = target[i];
                    string results = Array.Find(fooArray, element => element.StartsWith(v, StringComparison.Ordinal));
                    //
                    if (results != null)
                    { MessageBox.Show(results); }
                
            }
