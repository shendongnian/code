            public string Name
            {
                get
                {
                    return (_context["Test.Name"] ?? _context["TestName"]) as string;
                }
            }
