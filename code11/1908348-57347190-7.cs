    public class ItemsTests : IClassFixture<IDatabase>
    {
        private readonly IDatabase db;
        public ItemsTests( IDatabase db )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
        [Fact]
        public async Task Load_items_passes_the_ronseal_challenge()
        {
            ItemsViewModel vm = new ItemsViewModel( this.db );
            Assert.Equal( 0, vm.Items.Count );
            await vm.LoadItemsAsync();
            Assert.Equal( 5, vm.Items.Count );
        }
    }
