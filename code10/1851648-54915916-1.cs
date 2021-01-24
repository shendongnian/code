    using NodaTime;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Threading.Tasks;
    using System.Threading.Tasks;
    namespace MyNamespace.Products
    {
        public class ItemWebService : IItemService
        {
            private readonly IApiRestClient _restClient;
            private readonly string _serviceUrl = "api/products";
            private static IEnumerable<ProductListItem> _cachedProductist = null;
            private readonly IClock _clock;
            private readonly Duration _productlistValidFor = Duration.FromHours(1); // Set the timeout
            private static Instant _lastUpdate = Instant.MinValue;
    
    
            public ItemWebService (IApiRestClient restClient)
            {
                _restClient = restClient;
                _clock = SystemClock.Instance; // using NodaTime
            }
    
            public async Task AddGetProductAsync(AddProductRequest addProductRequest)
            {
                await _restClient.Put($"{_serviceUrl}/add", addProductRequest);
                // Expire cache manually to update product list on next call
                _lastUpdate = _clock.GetCurrentInstant() - _productlistValidFor ;
            }
    
            public async Task<IObservable<ProductListItem>> GetProductListAsync()
            {
                if (_cachedProductist == null || (_lastUpdate + _productlistValidFor) < _clock.GetCurrentInstant())
                {
                    _cachedProductist = await _restClient.Get<IEnumerable<ProductListItem>>($"{_serviceUrl}/productList");
                    
                    // Update the last updated time
                    _lastUpdate = _clock.GetCurrentInstant();
                }
                return _cachedProductist.ToObservable();
            }
        }
    }
