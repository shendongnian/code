    DataTable dt1 = user.getData();
    DataTable dt2 = user.getOldData();
    var results = from p2 in dt2.AsEnumerable()
              join p1 in dt1.AsEnumerable()
              on p2["XPNNUM"].ToString() equals (string)p1["pid"]
              into a
              from b in a.DefaultIfEmpty()
              select new
              {
                    XPNNUM = p2["XPNNUM"].ToString(),
                    XPNNAM = (string)p2["XPNNAM"],
                    XPNGRD = (string)p2["XPNGRD"],
                    user_id = b?["user_id"]?.ToString(),
                    firstname = b?["firstname"]?.ToString(),
                    usertype = b?["usertype"]?.ToString(),
                    subid = b?["subid"]?.ToString(),
              };
