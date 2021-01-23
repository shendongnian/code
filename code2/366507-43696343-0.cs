    new System.Threading.Timer((s) =>
                {
                    comboBox1.Invoke(new Action(() =>
                    {
                        comboBox1.Select(0, 0);
                    }));
                }, null, 10, System.Threading.Timeout.Infinite);
