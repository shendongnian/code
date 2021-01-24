     /// <summary>
        /// Creates a <see cref="CreatedAtRouteResult"/> object that produces a <see cref="StatusCodes.Status201Created"/> response.
        /// </summary>
        /// <param name="routeName">The name of the route to use for generating the URL.</param>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created <see cref="CreatedAtRouteResult"/> for the response.</returns>
        [NonAction]
        public virtual CreatedAtRouteResult CreatedAtRoute(string routeName, [ActionResultObjectValue] object value)
            => CreatedAtRoute(routeName, routeValues: null, value: value);
