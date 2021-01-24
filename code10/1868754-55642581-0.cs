cs
using System.Threading.Tasks;
using Microsoft.Bot.Schema;
namespace Microsoft.Bot.Builder
{
    /// <summary>
    /// Transcript logger stores activities for conversations for recall.
    /// </summary>
    public interface ITranscriptLogger
    {
        /// <summary>
        /// Log an activity to the transcript.
        /// </summary>
        /// <param name="activity">The activity to transcribe.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        Task LogActivityAsync(IActivity activity);
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.bot.builder.itranscriptlogger
