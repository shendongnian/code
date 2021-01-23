    var node = doc.Descendants(ns + "EmployerTPASeparationResponse").Single();
    using (cmd4) {
        foreach(var param in node.Elements()) {
            cmd4.Parameters.AddWithValue(param.Name.LocalName, param.Value);
        }
        cmd4.ExecuteNonQuery();
    }
