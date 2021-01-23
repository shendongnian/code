        private IGuy DefaultDood()
        {
            var guyStub = MockRepository.GenerateStub<IGuy>();
            guyStub.Expect(u => u.DrinkHouseholdProducts(Arg<string>.Is.Anything)).WhenCalled(invocation =>
				{
					guyStub.JustDrank = ((string)invocation.Arguments.First());
					guyStub.FeelingWell = false;
				}
            );
            return guyStub;
        }
