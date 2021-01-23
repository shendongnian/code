    var newList = list.ToFormattedList(
        2,
        args =>
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<div>");
            stringBuilder.Append(args[0].Name);
            if (args.Count > 1)
                stringBuilder.Append(args[1].Name);
            stringBuilder.Append("</div>");
            return stringBuilder.ToString();
        });
