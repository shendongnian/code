        public class Foo
        {
            public string myProperty = "foobar";
            //case #1:
            public Task t = Task.Factory.StartNew(() =>
            {
                //THIS won't compile: A field initializer cannot reference the non-static field, method, or property
                myProperty = "test";
            });
            //case #2:
            public Task GetTask() //THIS will work
            {
                Task t = Task.Factory.StartNew(() =>
                {
                    myProperty = "test";
                });
                return t;
            }
        }
