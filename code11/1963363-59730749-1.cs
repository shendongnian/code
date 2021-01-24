        [HttpDelete("{id}")]
        public async Task<RolloutPlan> Delete(int id)
        {
            // Explicitly include children here,
            // because lazy-loading them on serialization will fail.
            var parent = await _context
                .ParentEntities
                .Include(p => p.Children)
                .SingleAsync(p => p.Id == id);
            _context.ParentEntities.Remove(parent);
            _context.SaveChanges();
            return parent;
        }
