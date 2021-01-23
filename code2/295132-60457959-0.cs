    internal class LDialogService : ILDialogService, ILDialogInternalService
    {
        public async Task<TValue> ShowAsync<TValue>(ILDialogFragment fragment)
        {
            throw new NotImplementedException();
        }
        void ILDialogInternalService.SetComponent(LDialog component)
        {
            throw new NotImplementedException();
        }
    }
