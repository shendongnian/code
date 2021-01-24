    public async Task<IActionResult> GetCertificate(int id)
    {
        var language = await _context.Languages.FindAsync(id);
        if (language == null)
            return NotFound();
        return File(language.Certificate, "application/pdf");
    }
