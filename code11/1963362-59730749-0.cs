        [HttpDelete("{id}")]
        public async Task<RolloutPlan> Delete(int id)
        {
            // Explicitly include children here,
            // because lazy-loading them on serialization will fail.
            var rolloutPlan = await _context
                .ParentEntities
                .Include(p => p.Children)
                .SingleAsync(p => p.Id == id);
            _context.ParentEntities.Remove(rolloutPlan);
            _context.SaveChanges();
            return rolloutPlan;
        }
