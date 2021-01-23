    string GetChildren(Parameter param, string indent)
    {
        StringBuilder sb = new StringBuilder();
        if (HasChildren(param))
        {
            sb.AppendFormat("{0}<{1}>{2}", indent, param.Name, Environment.NewLine);
            foreach (Parameter child in parameters.Where(p => p.ParentType == param.Type))
            {
                sb.Append(GetChildren(child, indent + "   "));
            }
            sb.AppendFormat("{0}</{1}>{2}", indent, param.Name, Environment.NewLine);
        }
        else
        {
            sb.AppendFormat("{0}<{1}>{2}</{1}>{3}", indent, param.Name, param.Type, Environment.NewLine);
        }
        return sb.ToString();
    }
