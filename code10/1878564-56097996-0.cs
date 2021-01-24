csharp
public class GameHub : Hub
{
    public async Task UserLoggedIn(string userName)
    {
        await Clients.All.SendAsync("SendUserLoggedInMessage", userName);
    }
}
Then in js code
javascript
<script>
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/gameHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.start().then(() => {
        console.log("connected");
    });
    // listen on SendUserLoggedInMessage
    connection.on("SendUserLoggedInMessage", (userName) => {
        console.log("User Logged In" + userName);
    });
    // invoke UserLoggedIn method
   connection.send("userLoggedIn", username)
              .then(() => console.log("something"));
