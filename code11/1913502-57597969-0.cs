string[] lines = cmd.Split('"');
if (lines.Length > 1)
{
    ProcessStartInfo process = new ProcessStartInfo(lines[1].Trim());
    process.UseShellExecute = true;
    if (lines.Length > 2)
        process.Arguments = lines[2].Trim();
    Process.Start(process);
}
