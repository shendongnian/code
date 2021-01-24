    string Foo(Resource parameter = null)
            {
                if (parameter != null)
                {
                    parameter.Something();
                    return;
                }
                using (var res = new Resource())
                {
                    return Foo(res);
                }
            }
