            string[] states = new string[] { "AK", "WA", "OR", "CA", "AZ", "NM", "CO", "UT" };
            if (!states.Contains(state))
                WriteLine("\n***ERROR.  We do not ship to {0}.", state);
        }
~~~~
