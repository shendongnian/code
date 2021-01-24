            foreach (var item in this.Controls)
            {
                //Get item from form
                dynamic element = item;
                //check if there is any property called Borderstyle exists
                var res = item.GetType().GetProperties().Where(p => p.Name.Equals("BorderStyle")).FirstOrDefault();
                //if it exists and value is not equal None(Control have border)
                if (res !=null && !(res.GetValue(item).Equals("None")))
                {
                res.SetValue(item, BorderStyle.FixedSingle, null);
                //your other commands
                }
            }
