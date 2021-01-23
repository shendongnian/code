            Foobar c = new Foobar();
            c.Name = "ponies";
            var y = TryValidateModel(c);
            if (!y)
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var err in item.Errors)
                    {
                        DoxLog.Error(err.ErrorMessage, err.Exception);
                    }
                }
            }
