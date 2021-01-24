                List<RatingDto> _existingRatings = new List<RatingDto>(); 
                List<RatingDto> _targetRatings = new List<RatingDto>();
                Boolean _targetHasMissingRatings = false;
                foreach (var existing in _existingRatings)
                {
                    foreach (var target in _targetRatings)
                    {
                        if (existing == target)
                        {
                             _targetHasMissingRatings = true;
                             break;
                        }
                    }
                    if (_targetHasMissingRatings == true) break;
                }
