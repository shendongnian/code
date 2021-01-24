    @page "/CountDown"
    @using System.Timers
    @using ClientTImer
    @using Microsoft.FSharp.Core
    @using System.Threading
    
    <h3>Count Down</h3>
    <p>
        Task: @task <br />
        Status: @status
    </p>
    <p>
        Timer: @time
    </p>
    
    @code {
        string task = "";
        string status = "";
        int startCount = 5;
        int time;
    
        protected override async Task OnInitializedAsync()
        {
            time = startCount;
    
            // Initial task and status
            task = "First Task";
            status = "Status One";
    
            Action<System.Timers.ElapsedEventArgs> timeEvent =
                t =>
                {
                    UpdateTime().Wait();
                };
    
            var func = FuncConvert.ToFSharpFunc(timeEvent);
    
            await new ClientTImer.Timer(startCount).SetTimeAsTask(func,1);
    
            // Update task and status
            task = "Second Task";
            status = "Status Two";
            await new ClientTImer.Timer(startCount).SetTimeAsTask(func,1);
    
            // Update task and status
            task = "Third Task";
            status = "Status Three";
    
        }
    
        public async Task UpdateTime()
        {
            await InvokeAsync(() =>
            {
                time--;
                
                if(time <= 0)
                {
                    time = startCount;
                }
                
                StateHasChanged();
            });
        }
    
    }
