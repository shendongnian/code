        [HttpPost]
        public MvcHtmlString Detail(string id)
        {
            var d = _db.GetVehicle(Convert.ToInt32(id));
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Type: {0}</br>", d.Type));
            sb.AppendLine(string.Format("Brand: {0}</br>", d.Brand));
            sb.AppendLine(string.Format("Model: {0}</br>", d.Model));
            sb.AppendLine(string.Format("Number: {0}</br>", d.Number));
            sb.AppendLine(string.Format("Year: {0}</br>", d.Year));
            sb.AppendLine(string.Format("Cost: {0}</br>", d.Cost));
            return new MvcHtmlString(sb.ToString());
        }
