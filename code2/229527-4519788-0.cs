     var body = query.Body as BinaryExpression;
     if (body != null)
     {
        var left = body.Left as MemberExpression;
        if (left != null)
        {
            Console.WriteLine(left.Member.Name);   
             // You can get "Username" or "Email" here
        }
     }
