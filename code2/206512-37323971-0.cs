        /// <summary>
        /// Gets a <see cref="ServiceController"/> given the specified <see cref="pServiceName"/>.
        /// </summary>
        /// <param name="pServiceName">The name of the service.</param>
        /// <param name="pService">The <see cref="ServiceController"/> associated with the name.</param>
        /// <returns>
        /// <see cref="bool.True"/> if the <see cref="ServiceController"/> exists; otherwise <see cref="bool.False"/>.
        /// </returns>
        private static bool TryGetService(string pServiceName, out ServiceController pService)
        {
            pService = ServiceController.GetServices()
                .FirstOrDefault(serviceController => serviceController.ServiceName == pServiceName);
            return pService != null;
        }
