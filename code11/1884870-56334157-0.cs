    var list = new List<String>();
            list.Add("FamilyID;name;gender;DOB;Place of birth;status");
            list.Add("1;nicky;male;01-01-1998;greenland;married");
            list.Add("1;sonia;female;02-02-1995;greenland;married");
            list.Add("2;dicky;male;04-01-1995;bali;single");
            list.Add("3;redding;male;01-05-1996;USA;single");
            list.Add("3;sisca;female;05-03-1994;australia;married");
            var group = from item in list.Skip(1)
                        let splitItem = item.Split(';', StringSplitOptions.RemoveEmptyEntries)
                        select new
                        {
                            FamilyID = splitItem[0],
                            Name = splitItem[1],
                            Status = splitItem[5],
                        };
            foreach(var item in group.ToList())
            {
                Console.WriteLine($"Family ID: {item.FamilyID}, Name: {item.Name}, Status: {item.Status}");
            }
