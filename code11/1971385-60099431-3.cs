cs
public ApiCallResponse<T?> CallExternalAPI<T>(ApiCallInput input) where T : struct
{
	return Call<T>(input);
}
Or specify the generic type parameter, like
cs
var result = Call<double>(new ApiCallInput());
the result will have `ApiCallResponse<double?>` type.
---
This code will never compile
cs
public ApiCallResponse CallExternalAPI(ApiCallInput input)
{
    return Call(input);
}
The error message tells you an exact problem
> Try specifying the type arguments explicitly.
You should specify the generic type argument, something like pointed above
