    public static string SerializeInvoice(PosInvoice invoice, bool serializeDecimalsAsStrings)
    {
        var settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
        if (serializeDecimalsAsStrings)
        {
            settings.Converters.Add(new InvoiceAmountsAsStringsConverter());
        }
        return JsonConvert.SerializeObject(invoice, settings);
    }
