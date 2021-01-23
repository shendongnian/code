    var tests = new[] 
            {
                new { From = new DateTime(1900, 1, 1), To = new DateTime(1900, 1, 1), Result = 0 },
                new { From = new DateTime(1900, 1, 1), To = new DateTime(1900, 1, 2), Result = 0 },
                new { From = new DateTime(1900, 1, 2), To = new DateTime(1900, 1, 1), Result = 0 },
                new { From = new DateTime(1900, 1, 1), To = new DateTime(1900, 2, 1), Result = 1 },
                new { From = new DateTime(1900, 2, 1), To = new DateTime(1900, 1, 1), Result = 1 },
                new { From = new DateTime(1900, 1, 31), To = new DateTime(1900, 2, 1), Result = 0 },
                new { From = new DateTime(1900, 8, 31), To = new DateTime(1900, 9, 30), Result = 0 },
                new { From = new DateTime(1900, 8, 31), To = new DateTime(1900, 10, 1), Result = 1 },
                new { From = new DateTime(1900, 1, 1), To = new DateTime(1901, 1, 1), Result = 12 },
                new { From = new DateTime(1900, 1, 1), To = new DateTime(1911, 1, 1), Result = 132 },
                new { From = new DateTime(1900, 8, 31), To = new DateTime(1901, 8, 30), Result = 11 },
            };
