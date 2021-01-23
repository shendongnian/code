    Response.Cookies.Add(new HttpCookie("userID")
            {
                Expires = DateTime.Now.AddDays(1),
                Value = reader.GetString("use_id"),
                HttpOnly = true
            });
