        using System.ComponentModel.DataAnnotations;
        [Route("deletefavorite")]
        public ActionResult<Favorites> DeleteFavorites([FromQuery][Required]Guid userId, [FromQuery][Required][MaxLength(5)]string key)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return NotFound($"Error 404: Could not delete {key}");
        }
