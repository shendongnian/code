            List<Pic> intTime = new List<Pic>();
            intTime.Add(new Pic() { when = DateTime.Now, val = 0 });
            intTime.Add(new Pic() { when = DateTime.Now.AddDays(-1), val = 1 });
            intTime.Add(new Pic() { when = DateTime.Now.AddDays(-1.01), val = 2 });
            intTime.Add(new Pic() { when = DateTime.Now.AddDays(-1.02), val = 3 });
            intTime.Add(new Pic() { when = DateTime.Now.AddDays(-2), val = 4 });
            intTime.Add(new Pic() { when = DateTime.Now.AddDays(-2.1), val = 5 });
            intTime.Add(new Pic() { when = DateTime.Now.AddDays(-2.2), val = 6 });
            intTime.Add(new Pic() { when = DateTime.Now.AddDays(-3), val = 7 });
