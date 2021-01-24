    public BarangViewModel GetBarang()
    {
         var barang = new List<Barang>();
         var detailbarang = new List<DetailBarang>();
         var joinbarang =  _context.Barang.Join(_context.DetailBarang, p => p.IdBarang,
         m => m.IdBarang, (p,m) => new { barang = p, detailbarang = m }).ToList();
         foreach (var item in joinbarang)
         {
         barang.Add(item.barang);
         detailbarang.Add(item.detailbarang);
         }
         var result = new BarangViewModel();
         result.BarangV = barang;
         result.DetailBarangV = detailbarang;
    
         return result;
    }
