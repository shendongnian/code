    private void mapNames(InfoDto source, Info destination)
        {
            if (source.Names != null && source.Names.Any())
            {
                destination.Names = source.Names;
            }
        }
