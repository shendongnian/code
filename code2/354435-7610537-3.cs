    IContainer container = new Container(
                x =>
                    {
                        x.Scan(scan =>
                                   {
                                       scan.Assembly("MBP_Blog");
                                       scan.Assembly("MBP_Blog.Data");
                                       scan.WithDefaultConventions();
                                   });
                    });
