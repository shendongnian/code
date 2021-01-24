csharp
public sealed class AppInsightsRequestAttribute : Attribute, IMethodAsyncAdvice
    {
        private static readonly TelemetryClient TelemetryClient = new TelemetryClient(TelemetryConfiguration.Active);
        public async Task Advise(MethodAsyncAdviceContext context)
        {
            var parameters = context.TargetMethod.GetParameters();
            var parameterDescription = string.Join(", ",
                parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
            var signature = $"{context.Target ?? context.TargetType}.{context.TargetName}({parameterDescription})";
            using (var operation = TelemetryClient.StartOperation<RequestTelemetry>(signature))
            {
                try
                {
                    await context.ProceedAsync();
                }
                catch (Exception)
                {
                    operation.Telemetry.Success = false;
                    throw;
                }
                finally
                {
                    EnrichRequestTelemetry(operation.Telemetry, context, parameters);
               }
            }
        }
        private static void EnrichRequestTelemetry(ISupportProperties telemetry, MethodAsyncAdviceContext context, IReadOnlyList<ParameterInfo> parameters)
        {
            telemetry.Properties.Add(
                new KeyValuePair<string, string>("Accessibility", 
                    context.TargetMethod.Attributes.ToVisibilityScope().ToString()));
            for (var i = 0; i < context.Arguments.Count; i++)
            {
                telemetry.Properties.Add($"ARG {parameters[i].Name}", context.Arguments[i].ToString());
            }
        }
    }
This code will create a RequestTelemetry item and send it to application insights. The `EnrichRequestTelemetry` method will add the method arguments and values as custom properties to the item.
You can then decorate your methods like this: (there are more options, but this is to demonstrate a possibility)
csharp
public class SomeClass
    {
        [AppInsightsRequest]
        public async Task<string> SayHello(string to)
        {
            var telemetryClient = new TelemetryClient(TelemetryConfiguration.Active);
            string response = null;
            
            try
            {
                var greeting = $"Hello {to}";
                telemetryClient.TrackTrace($"Sending {greeting}");
                response = await SomeService.SendAsync(greeting);
            }
            catch (Exception exception)
            {
                telemetryClient.TrackException(exception);
            }
            return response;
        }
    }
A complete sample using a console application to send telemetry to application insights can be found in [this repository](https://github.com/Ibis-Software/AppInsightsDemo/tree/master/src/NonWebIntegrationDemo) which I created.
