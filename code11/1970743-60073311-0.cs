         public async Task<IActionResult> DeleteMultipleRows(int[] resultatenLijst, List<Resultaat> resultList)
        {
            var resultaat = await _context.Resultaat.FindAsync(0);
            foreach (var resultaatId in resultatenLijst)
            {
                resultaat = await _context.Resultaat.FindAsync(resultaatId);
                resultList.Add(resultaat);
            }
            _context.Resultaat.RemoveRange(resultList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Aanpassen));
        }
