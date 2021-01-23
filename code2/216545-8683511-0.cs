       Customer _custObj;
            using (RazorOne rz1 = new RazorOne())
            {
                 _custObj = rz1.Customers.FirstOrDefault();      //  .Include = Lazy loading
                // Versus Implicit Load
                _custObj.AddressReference.Load();
                 _custObj.Address1Reference.Load();
            }
