        /// <summary>
        /// Limits the locationsToFind variable to the maximum available locations. This avoids attempting to 
        /// mark more locations than are available for our width and height. 
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="locationsToFind"></param>
        /// <returns></returns>
        public int LimitLocationsToFindToMaxLocations(int height, int width, int locationsToFind)
        {
            return Math.Min(locationsToFind, height * width);
        }
