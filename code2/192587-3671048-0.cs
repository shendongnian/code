            ArrayList people = new ArrayList();
            people.Add(new Doctor());
            people.Add(new Lawyer());
            people.Add(new PetDetective());
            people.Add(new Ferrari()); // Yikes!
            // ...
            for (int i = 0; i < people.Count; i++)
            {
                object person = people[0];
                // ...
            }
