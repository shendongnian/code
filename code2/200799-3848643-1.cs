    var query = from list in db.Lists
                let split = list.LabelNumber.Split('.')
                let order = split.Length == 1
                    ? new { a = int.Parse(split[0]), b = String.Empty }
                    : new { a = int.Parse(split[0]), b = split[1] }
                orderby order.a, order.b
                select list.LabelNumber;
