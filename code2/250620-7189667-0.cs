    public class ClientSummaryMappingOverride : IAutoMappingOverride<ClientSummary>
    {
        public void Override(AutoMapping<ClientSummary> mapping)
        {
            mapping.References(x => x.Totals, "Totals_id");
            mapping.References(x => x.In_Totals, "In_Totals_id");
            mapping.References(x => x.Out_Totals, "Out_Totals_id");
            mapping.References(x => x.Direct_Totals, "Direct_Totals_id");
            mapping.References(x => x.CPN_Totals, "CPN_Totals_id");
        }
    }
