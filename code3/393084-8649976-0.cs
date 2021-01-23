            // Note that ModelsContainer derives from DbContext
            ModelsContainer context = new ModelsContainer();
            var weapons = context.Items.OfType<Weapon>();
            foreach (var weapon in weapons)
            {
                Console.WriteLine(weapon.Name + ":" + weapon.Attack);
            }
            var armours = context.Items.OfType<Armour>();
            foreach (var armour in armours)
            {
                Console.WriteLine(armour.Name + ":" + armour.Defense);
            }
