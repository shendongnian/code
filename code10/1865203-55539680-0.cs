    .AfterMap((src, dest, ctx) =>
    {
       var checks = ctx.Mapper.Map<IList<Destination>>(src.Checks);
       var wires = ctx.Mapper.Map<IList<Destination>>(src.Wires);
       dest.Payments = checks.Concat(wires).ToList();
    });
