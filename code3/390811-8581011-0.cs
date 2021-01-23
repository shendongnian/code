            set
            {
                //crash!
                if (value != name)
                {
                    name = value; // <-- Argh! Recursion!
                    hi(name); 
                }
            }
