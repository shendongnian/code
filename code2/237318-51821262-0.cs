		public static void JsonData() {
			var dbpath = Web.MapPath(@"your-password-file.kdbx");
			var masterpw = "Your$uper$tr0ngMst3rP@ssw0rd";
			var ioConnInfo = new IOConnectionInfo { Path = dbpath };
			var compKey = new CompositeKey();
			compKey.AddUserKey(new KcpPassword(masterpw));
			var db = new KeePassLib.PwDatabase();
			db.Open(ioConnInfo, compKey, null);
			//get everything
			var kpdata = from entry in db.RootGroup.GetEntries(true)
									 select new {
										 Group = entry.ParentGroup.Name,
										 Title = entry.Strings.ReadSafe("Title"),
										 Username = entry.Strings.ReadSafe("UserName"),
										 Password = entry.Strings.ReadSafe("Password"),
										 URL = entry.Strings.ReadSafe("URL"),
										 Notes = entry.Strings.ReadSafe("Notes")
									 };
			var kproot = db.RootGroup.Groups;
			string lastGroup = "#";
			uint sc = 0;
			int depth = 0;
			var parent = "#"; //root is # parent
			foreach (var entry in kproot) {
				PwGroup pwGroup = db.RootGroup.Groups.GetAt(sc);
				Web.Write(" { \"id\" : \"" + (sc) + "\", \"parent\" : \"" + parent + "\", \"text\" : \"" + pwGroup.Name.HtmlEncode() + "\" },\n");
				WriteChildren(pwGroup,sc+"", depth + 1);
				sc++;
			}
			db.Close();
		}
		public static void WriteChildren(PwGroup pwGroup, string parentID,int depth) {
			uint sc = 0;
			//if(depth>3)return;  //used to prevent too much recursion
			foreach (var entry in pwGroup.Groups) {
				var subGroup = pwGroup.Groups.GetAt(sc);
				var curID = (parentID+"_"+sc);
				Web.Write(" { \"id\" : \"" + curID + "\", \"parent\" : \"" + parentID + "\", \"text\" : \"" + subGroup.Name.JsEncode() + "\"},\n");
				WriteChildren(subGroup, curID, depth+1);
				WriteLeaves(subGroup, curID, depth);
				sc++;
			}
		}
		public static void WriteLeaves(PwGroup pwGroup, string parentID,int depth) {
			uint sc = 0;
			//if(depth>3)return;
			var entryList = pwGroup.GetEntries(false);
			foreach (var entry in entryList) {
				var curID = (parentID+"_"+sc);
				Web.Write(" { \"id\" : \"" + curID + "\", \"parent\" : \"" + parentID + "\", \"text\" : \"" + entry.Strings.ReadSafe("Title").JsEncode() + "\", \"password\" : \"" + entry.Strings.ReadSafe("Password").JsEncode() + "\", \"type\" : \"file\"},\n");
				sc++;
			}
		}
