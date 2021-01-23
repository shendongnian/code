        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                                                              {
                                                                  using (var form = new Form1())
                                                                  {
                                                                      form.ShowDialog();
                                                                  }
                                                              };
            throw new Exception();
        }
