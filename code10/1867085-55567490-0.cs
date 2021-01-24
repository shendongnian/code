        [HttpPost("id")] <----------
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactDelete([FromRoute(Name = "id" )] int id) <----------
        {
            var contact = await _db.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            _db.Contact.Remove(contact);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
