            foreach (var group in NewMainGroup.GetType().GetFields())
            {
                var groupInstance = group.GetValue(NewMainGroup);
                foreach (var subGroup in groupInstance.GetType().GetFields())
                {
                    Response.Write("<br />" + subGroup.Name + " = " + subGroup.GetValue(groupInstance));
                }
            }
