    // Are you *sure* you want to use ASCII? UTF-8 might be a better bet...
    using (TextWriter writer = File.CreateText("Shipping2.txt", Encoding.ASCII))
    {
        foreach (var shipment in _shipments)
        {
            // Removed redundant ToString call, and elided local variable.
            // Consider using a format string instead:
            // writer.WriteLine("{0},{1}", shipment.Distance, shipment.Distance);
            writer.WriteLine(shipment.Distance + "," + shipment.Distance);
        }
        // Removed empty statement (trailing semi-colon)
    }
