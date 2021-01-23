    using System;
    using System.Linq;
    using Nito.KitchenSink.OptionParsing;
    class Program
    {
      private sealed class GlobalOptions : OptionArgumentsBase
      {
        // Use a better name than "POption". This is just an example.
        [Option('p', OptionArgument.None)]
        public bool POption { get; set; }
        // Override Validate to allow AdditionalArguments.
        public override void Validate()
        {
        }
      }
      private sealed class AddOptions : OptionArgumentsBase
      {
        [Option('p', OptionArgument.None)]
        public bool POption { get; set; }
      }
      static int Main()
      {
        try
        {
          // Parse the entire command line into a GlobalOptions object.
          var options = OptionParser.Parse<GlobalOptions>();
          // The first entry in AdditionalArguments is our sub-command.
          if (options.AdditionalArguments.Count == 0)
            throw new OptionParsingException("No sub-command specified.");
          object subcommandOptions = null;
          string subcommand = options.AdditionalArguments[0];
          switch (subcommand)
          {
            case "add":
            {
              // Parse the remaining arguments as command-specific options.
              subcommandOptions = OptionParser.Parse<AddOptions>(options.AdditionalArguments.Skip(1));
              break;
            }
            case "status": // TODO: Parse command-specific options for this, too.
              break;
            case "diff": // TODO: Parse command-specific options for this, too.
              break;
            default:
              throw new OptionParsingException("Unknown sub-command: " + subcommand);
          }
          // At this point, we have our global options, subcommand, and subcommand options.
          Console.WriteLine("Global -p option: " + options.POption);
          Console.WriteLine("Subcommand: " + subcommand);
          var addOptions = subcommandOptions as AddOptions;
          if (addOptions != null)
            Console.WriteLine("Add-specific -p option: " + addOptions.POption);
          return 0;
        }
        catch (OptionParsingException ex)
        {
          Console.Error.WriteLine(ex.Message);
          // TODO: write out usage information.
          return 2;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine(ex);
          return 1;
        }
      }
    }
