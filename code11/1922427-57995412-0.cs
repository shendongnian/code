    action.Should()
        .Throw<SwaggerOpenApiException<IList<ApiValidationError>>>()
        .Which.Should().Match<SwaggerOpenApiException<IList<ApiValidationError>>>(
            e =>
                e.Result.Any(r => r.ErrorCode == errorCode) &&
                e.StatusCode == (int)HttpStatusCode.Conflict);
