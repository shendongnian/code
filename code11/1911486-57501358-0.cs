        public async Task<ReplyObj> GetAssets()
        {
            ReplyObj obj = new ReplyObj();
            return obj.Result = await _context.Asset.Select(s => new
            {
                AssetId = s.AssetId,
                Name = s.Name,
                Description = s.Description,
                PriceDecimals = s.PriceDecimals
            }).ToListAsync();
        }
