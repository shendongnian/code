    private string GetEmailAddress(DataTable dt) {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < dt.Rows.Count; i++) {
        sb.Append(dt.Rows[i]["Email"].ToString());
        if (i < dt.Rows.Count - 1)
          sb.Append(",");
      }
      sb.AppendLine();
      return sb.ToString();
    }
