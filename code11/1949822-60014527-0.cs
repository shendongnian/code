     if (email != null && !string.IsNullOrEmpty(email.Trim()))
            {
                var lst = new List<string>(
                    (email + "").Split(';').Select(tag => tag.Trim()).Where(tag => !string.IsNullOrEmpty(tag)));
                foreach (var s in lst)
                    msg.AddTo(s);
            }
