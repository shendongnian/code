    public IEnumerable<int> SafetyCouncilIds
    {
        set
        {
            StringBuilder sb = new StringBuilder(",");
    
            foreach (var id in value)
            {
                sb = sb.Append(id).Append(","); // <-- try this
                // *or sb = sb.AppendFormat("{0},", id);*
            }
    
            this.SafetyCouncilIdsString = sb.ToString();
        }
}
