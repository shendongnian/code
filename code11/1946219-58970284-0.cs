public async Task<List<ExperienceListDto>> GetFilteredExperiences(FilterExperienceDto filterExperience)
{
   var experiences = await _context.Experiences
.Where(x => x.Price >= filterExperience.MinPrice && x.Price <= filterExperience.MaxPrice && filterExperience.MinPrice.HasValue && filterExperience.MaxPrice.HasValue)
.Where(x.Rating == filterExperience.Rating && filterExperience.Rating.HasValue)
.Where(x.CountryId == filterExperience.CountryId && filterExperience.CountryId.HasValue)
            .ProjectTo<ExperienceListDto>().ToListAsync();
   return experiences;
}
