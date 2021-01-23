                var tempCurrentUICulture = Thread.CurrentThread.CurrentUICulture;
                try
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-HK" );
                     actual = target.MethodToTest(resourceSet, localeId);
                }
                finally
                {
                    Thread.CurrentThread.CurrentUICulture = tempCurrentUICulture;
                }
